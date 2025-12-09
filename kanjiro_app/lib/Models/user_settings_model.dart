import 'package:json_annotation/json_annotation.dart';
import 'package:mobx/mobx.dart';

part 'user_settings_model.g.dart';

@JsonSerializable(explicitToJson: true)
class UserSettingsModel extends UserSettingsModelBase with _$UserSettingsModel {
  UserSettingsModel({
    required super.id,
    super.darkMode,
    super.allowNotifications,
  });

  factory UserSettingsModel.fromJson(Map<String, dynamic> json) =>
      _$UserSettingsModelFromJson(json);

  Map<String, dynamic> toJson() => _$UserSettingsModelToJson(this);
}

abstract class UserSettingsModelBase with Store {
  UserSettingsModelBase({
    required this.id,
    this.darkMode = false,
    this.allowNotifications = false,
  });

  final int id;
  @observable
  bool darkMode = false;
  @observable
  bool allowNotifications = false;
}
