import 'dart:ffi';

import 'package:kanjiro_app/Models/card_info_model.dart';
import 'package:kanjiro_app/Utils/Enums/card_state.dart';

class CardModel {
  CardModel({
    required this.cardInfo,
    required this.cardState,
    required this.nextReviewDate,
    required this.mistakeCounter,
    required this.currentDifficultyMultiplier,
    required this.reviewDateCounter,
  });

  final CardInfoModel cardInfo;
  final CardState cardState;
  final DateTime nextReviewDate;
  final int mistakeCounter;
  final Float currentDifficultyMultiplier;
  final int reviewDateCounter;
}
