import 'package:kanjiro_app/Models/placement_test_card_model.dart';
import 'package:kanjiro_app/Services/api_service.dart';
import 'package:kanjiro_app/Utils/Enums/jlpt_level.dart';
import 'package:mobx/mobx.dart';

part 'placement_test_viewmodel.g.dart';

class PlacementTestViewmodel = PlacementTestViewmodelBase
    with _$PlacementTestViewmodel;

abstract class PlacementTestViewmodelBase with Store {
  @observable
  late List<PlacementTestCardModel> allPlacementCards;

  @observable
  bool isLoading = false;

  @observable
  JlptLevel currentLevel = JlptLevel.N5;

  @observable
  late List<PlacementTestCardModel> currentLevelPlacementCards;

  @observable
  bool isSecondPhase = false;

  @action
  Future init() async {
    isLoading = true;
    try {
      var cardInfos = await ApiService.placementTest();
      allPlacementCards =
          cardInfos
              .map(
                (info) => PlacementTestCardModel(cardInfo: info),
              )
              .toList();

      currentLevelPlacementCards =
          allPlacementCards
              .where((x) => x.cardInfo.jlptLevel == JlptLevel.N5)
              .take(20)
              .toList();
    } finally {
      isLoading = false;
    }
  }

  @action
  void selectCard(PlacementTestCardModel card) {
    card.isSelected = !card.isSelected;
  }

  @action
  void nextPage() {
    if (currentLevelPlacementCards.where((x) => x.isSelected).length >= 15) {
      switch (currentLevel) {
        case JlptLevel.N5:
          currentLevel = JlptLevel.N4;
          break;
        case JlptLevel.N4:
          currentLevel = JlptLevel.N3;
        case JlptLevel.N3:
          currentLevel = JlptLevel.N2;
        case JlptLevel.N2:
          currentLevel = JlptLevel.N1;
        case JlptLevel.N1: // TODO: implement logic here
        default: // TODO: implement logic here
      }

      currentLevelPlacementCards =
          allPlacementCards
              .where((x) => x.cardInfo.jlptLevel == currentLevel)
              .take(20)
              .toList();

      return;
    }

    currentLevelPlacementCards =
        allPlacementCards
            .where(
              (x) =>
                  x.cardInfo.jlptLevel == currentLevel &&
                  !currentLevelPlacementCards.contains(x),
            )
            .take(20)
            .toList();
    isSecondPhase = true;
  }

  @action
  void finishPlacementTest() {
    //TODO: Implement here -> API call sends the currentLevel and the amount of selected cards on that level (allPlacementCards.Where((x) => x.cardInfo.jlptLevel == currentLevel && x.isSelected)).length
  }
}
