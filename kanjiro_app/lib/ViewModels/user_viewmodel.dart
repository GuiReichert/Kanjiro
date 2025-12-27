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

  @observable
  late UserDeckViewmodel deckViewmodel;
  @observable
  late UserSettingsViewmodel settingsViewmodel;

  @action
  Future<void> loadUser(String userName, String password) async {
    var userApi = await ApiService.userLogin(userName, password);

    user = userApi;
    var currentDeck = user!.decks.firstWhere(
      (x) => x.id == user!.currentActiveDeckId,
      orElse: () => user!.decks.first,
    );

    deckViewmodel = UserDeckViewmodel(currentDeck: currentDeck);
    settingsViewmodel = UserSettingsViewmodel(userSettings: user!.settings);
  }

  @action
  Future<void> logoutUser() async {
    synchronizeChanges();
    user = null;
  }

  @action
  Future<void> synchronizeChanges() async {
    var userApi = await ApiService.synchronizeChanges(user!);

    user = userApi;
    var currentDeck = user!.decks.firstWhere(
      (x) => x.id == user!.currentActiveDeckId,
      orElse: () => user!.decks.first,
    );

    deckViewmodel = UserDeckViewmodel(currentDeck: currentDeck);
    settingsViewmodel = UserSettingsViewmodel(userSettings: user!.settings);
  }
}
