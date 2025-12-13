// ignore_for_file: constant_identifier_names

import 'package:json_annotation/json_annotation.dart';

enum CardState {
  @JsonValue(0)
  New,
  @JsonValue(1)
  Learning,
  @JsonValue(2)
  Reviewing,
  @JsonValue(3)
  Flagged,
  @JsonValue(4)
  Graduated,
}
