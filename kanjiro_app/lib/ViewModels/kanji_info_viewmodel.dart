import 'package:injector/injector.dart';
import 'package:kanjiro_app/Models/card_info_model.dart';
import 'package:kanjiro_app/Models/card_model.dart';
import 'package:kanjiro_app/Models/deck_model.dart';
import 'package:kanjiro_app/Utils/Enums/card_state.dart';
import 'package:kanjiro_app/ViewModels/user_viewmodel.dart';
import 'package:mobx/mobx.dart';

part 'kanji_info_viewmodel.g.dart';

class KanjiInfoViewmodel = KanjiInfoViewmodelBase with _$KanjiInfoViewmodel;

abstract class KanjiInfoViewmodelBase with Store {
  KanjiInfoViewmodelBase({required this.card});

  @action
  void init() {
    userViewmodel = Injector.appInstance.get<UserViewmodel>();
    deck = userViewmodel.deckViewmodel.currentDeck;
  }

  @observable
  late UserViewmodel userViewmodel;

  @observable
  late DeckModel deck;

  @observable
  CardInfoModel card;

  @computed
  bool get addedToDeck => deck.cards.any((x) => x.cardInfo.id == card.id);

  @action
  void addKanjiToDeck() {
    deck.cards.add(
      CardModel(
        id: 0,
        cardInfo: card,
        cardState: CardState.New,
        nextReviewDate: DateTime.now(),
        mistakeCounter: 0,
        currentDifficultyMultiplier: 1,
        reviewDateCounter: 0,
        userComment: '',
      ),
    );
  }
}
