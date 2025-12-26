import 'package:kanjiro_app/Models/card_info_model.dart';
import 'package:kanjiro_app/Models/placement_test_card_model.dart';
import 'package:kanjiro_app/Services/api_service.dart';
import 'package:mobx/mobx.dart';

part 'placement_test_viewmodel.g.dart';

class PlacementTestViewmodel = PlacementTestViewmodelBase
    with _$PlacementTestViewmodel;

abstract class PlacementTestViewmodelBase with Store {
  @observable
  late List<PlacementTestCardModel> cartasNivelamento;

  @observable
  bool isLoading = false;

  @action
  Future init() async {
    isLoading = true;
    try {
      var cardInfos = await ApiService.placementTest(5);
      cartasNivelamento =
          cardInfos
              .map(
                (info) => PlacementTestCardModel(cardInfo: info),
              )
              .toList();
    } finally {
      isLoading = false;
    }
  }

  @action
  void selectCard(PlacementTestCardModel card) {
    card.isSelected = !card.isSelected;
  }
}
