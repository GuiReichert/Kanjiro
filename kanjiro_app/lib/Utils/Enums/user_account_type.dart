// ignore_for_file: constant_identifier_names

import 'package:json_annotation/json_annotation.dart';

enum UserAccountType {
  @JsonValue(0)
  Normal,
  @JsonValue(2)
  Premium,
  @JsonValue(3)
  Premium_Plus,
}
