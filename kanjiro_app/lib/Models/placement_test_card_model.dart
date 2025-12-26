import 'package:kanjiro_app/Models/card_info_model.dart';
import 'package:mobx/mobx.dart';

part 'placement_test_card_model.g.dart';

class PlacementTestCardModel = PlacementTestCardModelBase
    with _$PlacementTestCardModel;

abstract class PlacementTestCardModelBase with Store {
  PlacementTestCardModelBase({required this.cardInfo});

  @observable
  bool isSelected = false;
  @observable
  CardInfoModel cardInfo;
}
