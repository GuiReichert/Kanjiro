import 'package:json_annotation/json_annotation.dart';
import 'package:kanjiro_app/Models/card_info_model.dart';
import 'package:kanjiro_app/Utils/Enums/card_state.dart';

part 'card_model.g.dart';

@JsonSerializable(explicitToJson: true)
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
  final double currentDifficultyMultiplier;
  final int reviewDateCounter;

  factory CardModel.fromJson(Map<String, dynamic> json) =>
      _$CardModelFromJson(json);

  Map<String, dynamic> toJson() => _$CardModelToJson(this);
}
