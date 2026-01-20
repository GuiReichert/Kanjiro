import 'package:flutter/widgets.dart';
import 'package:kanjiro_app/Models/stroke_point.dart';
import 'package:mobx/mobx.dart';

part 'kanji_drawing_canvas_viewmodel.g.dart';

class KanjiDrawingCanvasViewmodel = KanjiDrawingCanvasViewmodelBase
    with _$KanjiDrawingCanvasViewmodel;

abstract class KanjiDrawingCanvasViewmodelBase with Store {
  @observable
  ObservableList<ObservableList<StrokePoint>> strokes =
      ObservableList<ObservableList<StrokePoint>>();

  @observable
  ObservableList<StrokePoint> currentStroke = ObservableList<StrokePoint>();

  @action
  void clearCanvas() => strokes.clear();

  @action
  void undoLastStroke() => strokes.removeLast();
  @action
  void resetCurrentStroke() => currentStroke = ObservableList();
  @action
  void addStroke(Offset offset) =>
      currentStroke.add(StrokePoint(point: offset));

  @action
  void addCurrentStroke() => strokes.add(currentStroke);
}
