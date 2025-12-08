import 'package:json_annotation/json_annotation.dart';
import 'package:kanjiro_app/Models/deck_model.dart';
import 'package:kanjiro_app/Models/user_settings_model.dart';
import 'package:kanjiro_app/Utils/Enums/user_account_type.dart';

part 'user_model.g.dart';

@JsonSerializable(explicitToJson: true)
class UserModel {
  UserModel({
    required this.id,
    required this.decks,
    required this.userSettings,
    required this.accountType,
  });

  final int id;
  final List<DeckModel> decks;
  @JsonKey(name: "settings")
  final UserSettingsModel userSettings;
  final UserAccountType accountType;

  factory UserModel.fromJson(Map<String, dynamic> json) =>
      _$UserModelFromJson(json);

  Map<String, dynamic> toJson() => _$UserModelToJson(this);
}
