import 'package:google_mlkit_digital_ink_recognition/google_mlkit_digital_ink_recognition.dart';
import 'package:kanjiro_app/Models/singular_stroke.dart';

class KanjiRecognition {
  static final DigitalInkRecognizer _recognizer = DigitalInkRecognizer(
    languageCode: 'ja-JP',
  );

  static Future<List<RecognitionCandidate>> recognizeByStroke(
    List<List<SingularStroke>> strokes,
  ) async {
    await _downloadModelIfNeeded();
    var ink = _convertToInk(strokes);
    var candidates = await _recognizer.recognize(ink);

    for (var candidate in candidates) {
      print("${candidates.indexOf(candidate) + 1}) Kanji: ${candidate.text}");
    }

    return candidates;
  }

  static Future _downloadModelIfNeeded() async {
    final modelManager = DigitalInkRecognizerModelManager();

    if (!(await modelManager.isModelDownloaded('ja-JP'))) {
      await modelManager.downloadModel('ja-JP');
    }
  }

  static Ink _convertToInk(List<List<SingularStroke>> strokes) {
    final List<Stroke> inkStrokes = [];

    for (var strokeList in strokes) {
      Stroke currentStroke = Stroke();

      for (var singularStroke in strokeList) {
        currentStroke.points.add(
          StrokePoint(
            x: singularStroke.point.dx,
            y: singularStroke.point.dy,
            t: singularStroke.time.millisecondsSinceEpoch,
          ),
        );
      }

      inkStrokes.add(currentStroke);
    }

    Ink finalInk = Ink();
    finalInk.strokes = inkStrokes;

    return finalInk;
  }
}
