import 'package:json_annotation/json_annotation.dart';
import 'package:kanjiro_app/Models/deck_model.dart';
import 'package:kanjiro_app/Models/user_settings_model.dart';
import 'package:kanjiro_app/Utils/Enums/user_account_type.dart';

part 'user_model.g.dart';

@JsonSerializable(explicitToJson: true)
class UserModel {
  UserModel({
    required this.id,
    required this.userName,
    required this.nickName,
    required this.lastSyncDate,
    required this.decks,
    required this.settings,
    required this.accountType,
    required this.currentActiveDeckId,
  });

  final int id;
  final String userName;
  String nickName;
  DateTime? lastSyncDate;
  final List<DeckModel> decks;
  final UserSettingsModel settings;
  UserAccountType accountType;
  int currentActiveDeckId;

  factory UserModel.fromJson(Map<String, dynamic> json) =>
      _$UserModelFromJson(json);

  Map<String, dynamic> toJson() => _$UserModelToJson(this);
}
