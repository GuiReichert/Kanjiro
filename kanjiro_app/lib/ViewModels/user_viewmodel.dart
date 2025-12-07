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

  late UserDeckViewmodel deckViewmodel;
  late UserSettingsViewmodel settingsViewmodel;

  @action
  Future<void> loadUser(String userName, String password) async {
    var userApi = await ApiService.userLogin(userName, password);

    user = userApi;
    deckViewmodel = UserDeckViewmodel(decks: user!.decks);
    settingsViewmodel = UserSettingsViewmodel(userSettings: user!.userSettings);
  }
}
