import 'package:kanjiro_app/Models/user_settings_model.dart';
import 'package:mobx/mobx.dart';

part 'user_settings_viewmodel.g.dart';

class UserSettingsViewmodel = UserSettingsViewmodelBase
    with _$UserSettingsViewmodel;

abstract class UserSettingsViewmodelBase with Store {
  @observable
  UserSettingsModel userSettings = UserSettingsModel();
}
