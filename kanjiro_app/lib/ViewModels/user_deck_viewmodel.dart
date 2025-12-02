import 'package:kanjiro_app/Models/deck_model.dart';
import 'package:mobx/mobx.dart';

part 'user_deck_viewmodel.g.dart';

class UserDeckViewmodel = UserDeckViewmodelBase with _$UserDeckViewmodel;

abstract class UserDeckViewmodelBase with Store {
  @observable
  List<DeckModel> decks = [DeckModel(cards: [])];
}
