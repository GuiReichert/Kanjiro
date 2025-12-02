import 'package:json_annotation/json_annotation.dart';

part 'user_settings_model.g.dart';

@JsonSerializable(explicitToJson: true)
class UserSettingsModel {
  UserSettingsModel();

  factory UserSettingsModel.fromJson(Map<String, dynamic> json) =>
      _$UserSettingsModelFromJson(json);

  Map<String, dynamic> toJson() => _$UserSettingsModelToJson(this);
}
