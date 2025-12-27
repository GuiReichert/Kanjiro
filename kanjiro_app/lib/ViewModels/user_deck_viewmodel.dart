import 'package:kanjiro_app/Models/card_model.dart';
import 'package:kanjiro_app/Models/deck_model.dart';
import 'package:kanjiro_app/Utils/Enums/card_state.dart';
import 'package:mobx/mobx.dart';

part 'user_deck_viewmodel.g.dart';

class UserDeckViewmodel = UserDeckViewmodelBase with _$UserDeckViewmodel;

abstract class UserDeckViewmodelBase with Store {
  UserDeckViewmodelBase({required this.currentDeck});

  final DateTime today = DateTime.now().copyWith(
    hour: 23,
    minute: 59,
    second: 59,
    microsecond: 999,
  );

  @observable
  DeckModel currentDeck;

  @computed
  List<CardModel> get cardsToReview =>
      currentDeck.cards
          .where(
            (x) =>
                x.nextReviewDate.isBefore(today) &&
                x.cardState != CardState.Graduated,
          )
          .toList();

  @computed
  CardModel? get nextCardToReview => cardsToReview.firstOrNull;

  @action
  void updateCardReviewDate(CardModel card, double multiplier) {
    card.currentDifficultyMultiplier *= multiplier;
    card.nextReviewDate = today.add(
      Duration(
        days:
            ((card.reviewDateCounter == 0 ? 1 : card.reviewDateCounter) *
                    card.currentDifficultyMultiplier)
                .toInt(),
      ),
    );
  }
}
