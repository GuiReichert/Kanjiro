// ignore_for_file: constant_identifier_names

import 'package:json_annotation/json_annotation.dart';

enum JlptLevel {
  @JsonValue(0)
  None(0),
  @JsonValue(1)
  N1(1),
  @JsonValue(2)
  N2(2),
  @JsonValue(3)
  N3(3),
  @JsonValue(4)
  N4(4),
  @JsonValue(5)
  N5(5);

  final int value;
  const JlptLevel(this.value);
}
