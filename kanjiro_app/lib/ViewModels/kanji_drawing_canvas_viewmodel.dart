import 'package:flutter/widgets.dart';
import 'package:kanjiro_app/Models/singular_stroke.dart';
import 'package:kanjiro_app/Services/kanji_recognition.dart';
import 'package:mobx/mobx.dart';

part 'kanji_drawing_canvas_viewmodel.g.dart';

class KanjiDrawingCanvasViewmodel = KanjiDrawingCanvasViewmodelBase
    with _$KanjiDrawingCanvasViewmodel;

abstract class KanjiDrawingCanvasViewmodelBase with Store {
  @observable
  ObservableList<ObservableList<SingularStroke>> strokes =
      ObservableList<ObservableList<SingularStroke>>();

  @observable
  ObservableList<SingularStroke> currentStroke =
      ObservableList<SingularStroke>();

  @action
  void clearCanvas() => strokes.clear();

  @action
  void undoLastStroke() => strokes.removeLast();
  @action
  void resetCurrentStroke() {
    currentStroke = ObservableList();
  }

  Future recognizeKanji() async {
    //TODO: ver exatamente como será feito aqui
    await KanjiRecognition.recognizeByStroke(strokes);
  }

  @action
  void addStroke(Offset offset) =>
      currentStroke.add(SingularStroke(point: offset));

  @action
  void addCurrentStroke() => strokes.add(currentStroke);
}
