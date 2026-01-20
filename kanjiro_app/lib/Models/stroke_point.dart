import 'package:flutter/widgets.dart';

class StrokePoint {
  final Offset point;
  final DateTime time;

  StrokePoint({required this.point}) : time = DateTime.now();
}
