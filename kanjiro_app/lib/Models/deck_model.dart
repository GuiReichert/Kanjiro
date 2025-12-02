import 'package:json_annotation/json_annotation.dart';
import 'package:kanjiro_app/Models/card_model.dart';

part 'deck_model.g.dart';

@JsonSerializable(explicitToJson: true)
class DeckModel {
  DeckModel({required this.cards});

  final List<CardModel> cards;

  factory DeckModel.fromJson(Map<String, dynamic> json) =>
      _$DeckModelFromJson(json);

  Map<String, dynamic> toJson() => _$DeckModelToJson(this);
}
