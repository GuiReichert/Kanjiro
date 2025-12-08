import 'package:kanjiro_app/Models/card_model.dart';
import 'package:kanjiro_app/Models/deck_model.dart';
import 'package:mobx/mobx.dart';

part 'user_deck_viewmodel.g.dart';

class UserDeckViewmodel = UserDeckViewmodelBase with _$UserDeckViewmodel;

abstract class UserDeckViewmodelBase with Store {
  UserDeckViewmodelBase({required this.decks});

  final DateTime today = DateTime.now().copyWith(
    hour: 23,
    minute: 59,
    second: 59,
    microsecond: 999,
  );

  @observable
  List<DeckModel> decks;

  @computed
  List<CardModel> get cardsToReview =>
      decks.first.cards.where((x) => x.nextReviewDate.isBefore(today)).toList();

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
