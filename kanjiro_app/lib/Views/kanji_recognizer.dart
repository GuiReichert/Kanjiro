import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:injector/injector.dart';
import 'package:kanjiro_app/Models/stroke_point.dart';
import 'package:kanjiro_app/ViewModels/kanji_drawing_canvas_viewmodel.dart';

class KanjiRecognizer extends StatefulWidget {
  const KanjiRecognizer({super.key});

  @override
  State<KanjiRecognizer> createState() => _KanjiRecognizerState();
}

class _KanjiRecognizerState extends State<KanjiRecognizer> {
  final viewmodel = Injector.appInstance.get<KanjiDrawingCanvasViewmodel>();

  @override
  Widget build(BuildContext context) {
    return Observer(builder: (_) => _conteudo());
  }

  _conteudo() {
    return Scaffold(
      appBar: AppBar(
        title: Text('Kanji Recognizer'),
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          Container(
            width: 300,
            height: 300,
            color: Colors.amber,
            child: GestureDetector(
              onPanStart: (details) {
                // Precisa do SetState para atualizar o Painter
                setState(() {
                  viewmodel.resetCurrentStroke();
                  viewmodel.addCurrentStroke();
                });
              },
              onPanUpdate: (details) {
                setState(() {
                  final currentPoint = details.localPosition;

                  if (currentPoint.dx < 0 ||
                      currentPoint.dx > 300 ||
                      currentPoint.dy < 0 ||
                      currentPoint.dy > 300) {
                    viewmodel.resetCurrentStroke();
                    return;
                  }

                  viewmodel.addStroke(currentPoint);
                });
              },
              onPanEnd: (details) {
                setState(() {
                  viewmodel.resetCurrentStroke();
                });
              },
              child: CustomPaint(
                size: Size(300, 300),
                painter: KanjiPainter(strokes: viewmodel.strokes),
              ),
            ),
          ),
          Row(
            children: [
              Spacer(),
              IconButton(
                onPressed: viewmodel.undoLastStroke,
                icon: Icon(Icons.undo),
                iconSize: 60,
              ),
              IconButton(
                onPressed: viewmodel.clearCanvas,
                icon: Icon(Icons.delete),
                iconSize: 60,
              ),
            ],
          ),
        ],
      ),
    );
  }
}

class KanjiPainter extends CustomPainter {
  final List<List<StrokePoint>> strokes;

  KanjiPainter({super.repaint, required this.strokes});

  @override
  void paint(Canvas canvas, Size size) {
    final paint =
        Paint()
          ..color = Colors.black
          ..strokeWidth = 6
          ..strokeCap = StrokeCap.round;

    for (final stroke in strokes) {
      for (int i = 0; i < stroke.length - 1; i++) {
        canvas.drawLine(stroke[i].point, stroke[i + 1].point, paint);
      }
    }
  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) => true;
}
