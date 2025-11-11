import 'package:flutter/material.dart';
import 'package:kanjiro_app/Widgets/background_claro_widget.dart';

class CardReviewPage extends StatefulWidget {
  const CardReviewPage({super.key});

  @override
  State<CardReviewPage> createState() => _CardReviewPageState();
}

class _CardReviewPageState extends State<CardReviewPage> {
  bool mostrarResposta = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: KanjiroBackgroundClaro(
        widgetFilho: Center(
          child: Container(
            decoration: BoxDecoration(
              color: Colors.white.withValues(alpha: 0.75),
            ),
            child: Center(
              child: Text(
                'KANJI AQUI',
                style: TextStyle(fontSize: 35, fontWeight: FontWeight.bold),
              ),
            ),
          ),
        ),
      ),
      appBar: barraSuperiorCardReview(),
      bottomNavigationBar: BottomAppBar(
        color: const Color.fromARGB(255, 10, 40, 68).withValues(alpha: 0.8),
        child: mostrarResposta ? botoesDificuldade() : botaoMostrarResposta(),
      ),
    );
  }

  Center botaoMostrarResposta() {
    return Center(
      child: ElevatedButton(
        onPressed: () {
          setState(() {
            mostrarResposta = true;
          });
        },
        child: Text('Mostrar Resposta'),
      ),
    );
  }

  Row botoesDificuldade() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        ElevatedButton(onPressed: () {}, child: Text('Easy')),
        ElevatedButton(onPressed: () {}, child: Text('Normal')),
        ElevatedButton(onPressed: () {}, child: Text('Hard')),
      ],
    );
  }

  AppBar barraSuperiorCardReview() {
    return AppBar(
      backgroundColor: const Color.fromARGB(
        255,
        10,
        40,
        68,
      ).withValues(alpha: 0.8),
      elevation: 1,
      leadingWidth: 500,
      leading: Row(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Container(
            alignment: Alignment.centerLeft,
            margin: EdgeInsets.only(left: 10),
            child: Text('Voltar', style: TextStyle(color: Colors.white)),
          ),
          SizedBox(width: 300),
          Text('Opcões', style: TextStyle(color: Colors.white)),
        ],
      ),
    );
  }
}
