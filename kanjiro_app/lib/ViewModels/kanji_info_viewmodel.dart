import 'package:kanjiro_app/Models/card_info_model.dart';
import 'package:kanjiro_app/Models/deck_model.dart';
import 'package:mobx/mobx.dart';

part 'kanji_info_viewmodel.g.dart';

class KanjiInfoViewmodel = KanjiInfoViewmodelBase with _$KanjiInfoViewmodel;

abstract class KanjiInfoViewmodelBase with Store {
  KanjiInfoViewmodelBase({required this.card, required this.deck});

  @observable
  DeckModel deck;

  @observable
  CardInfoModel card;

  @computed
  bool get addedToDeck => deck.cards.any((x) => x.cardInfo.id == card.id);
}
