import 'package:kanjiro_app/Models/user_model.dart';
import 'package:kanjiro_app/Services/api_service.dart';
import 'package:kanjiro_app/ViewModels/user_deck_viewmodel.dart';
import 'package:kanjiro_app/ViewModels/user_settings_viewmodel.dart';
import 'package:mobx/mobx.dart';

part 'user_viewmodel.g.dart';

class UserViewmodel = UserViewModelBase with _$UserViewmodel;

abstract class UserViewModelBase with Store {
  @observable
  UserModel? user;

  UserDeckViewmodel deckViewmodel = UserDeckViewmodel();
  UserSettingsViewmodel settingsViewmodel = UserSettingsViewmodel();

  @action
  Future<void> loadUser(String userName, String password) async {
    var userApi = await ApiService.userLogin(userName, password);

    user = userApi;
    deckViewmodel.decks = user!.decks;
    settingsViewmodel.userSettings = user!.userSettings;
  }
}
