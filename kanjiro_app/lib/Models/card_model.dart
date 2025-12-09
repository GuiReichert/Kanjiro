import 'package:json_annotation/json_annotation.dart';
import 'package:kanjiro_app/Models/card_info_model.dart';
import 'package:kanjiro_app/Utils/Enums/card_state.dart';
import 'package:mobx/mobx.dart';

part 'card_model.g.dart';

@JsonSerializable(explicitToJson: true)
class CardModel extends CardModelBase with _$CardModel {
  CardModel({
    required super.id,
    required super.cardInfo,
    required super.cardState,
    required super.nextReviewDate,
    required super.mistakeCounter,
    required super.currentDifficultyMultiplier,
    required super.reviewDateCounter,
    required super.userComment,
  });

  factory CardModel.fromJson(Map<String, dynamic> json) =>
      _$CardModelFromJson(json);

  Map<String, dynamic> toJson() => _$CardModelToJson(this);
}

abstract class CardModelBase with Store {
  CardModelBase({
    required this.id,
    required this.cardInfo,
    required this.cardState,
    required this.nextReviewDate,
    required this.mistakeCounter,
    required this.currentDifficultyMultiplier,
    required this.reviewDateCounter,
    required this.userComment,
  });

  final int id;
  @JsonKey(name: 'info')
  final CardInfoModel cardInfo;
  @JsonKey(name: 'state')
  @observable
  CardState cardState;
  @observable
  DateTime nextReviewDate;
  @observable
  int mistakeCounter;
  @observable
  double currentDifficultyMultiplier;
  @observable
  int reviewDateCounter;
  @observable
  String userComment;
}
