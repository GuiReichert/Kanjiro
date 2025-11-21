import 'package:mobx/mobx.dart';

part 'user_settings_viewmodel.g.dart';

class UserSettingsViewmodel = UserSettingsViewmodelBase
    with _$UserSettingsViewmodel;

abstract class UserSettingsViewmodelBase with Store {}
