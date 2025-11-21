import 'package:mobx/mobx.dart';

part 'user_viewmodel.g.dart';

class UserViewmodel = UserViewModelBase with _$UserViewmodel;

abstract class UserViewModelBase with Store {}
