import 'package:kanjiro_app/Models/deck_model.dart';
import 'package:kanjiro_app/Models/user_settings_model.dart';
import 'package:kanjiro_app/Utils/Enums/user_account_type.dart';

class UserModel {
  UserModel({
    required this.decks,
    required this.userSettings,
    required this.accountType,
  });

  final List<DeckModel> decks;
  final UserSettingsModel userSettings;
  final UserAccountType accountType;
}
