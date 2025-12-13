import 'package:json_annotation/json_annotation.dart';
import 'package:kanjiro_app/Models/card_model.dart';
import 'package:mobx/mobx.dart';

part 'deck_model.g.dart';

@JsonSerializable(explicitToJson: true)
class DeckModel extends DeckModelBase with _$DeckModel {
  DeckModel({required super.id, required super.cards});

  factory DeckModel.fromJson(Map<String, dynamic> json) =>
      _$DeckModelFromJson(json);

  Map<String, dynamic> toJson() => _$DeckModelToJson(this);
}

abstract class DeckModelBase with Store {
  DeckModelBase({required this.id, required this.cards});

  int id;
  @observable
  @JsonKey(fromJson: _cardsFromJson, toJson: _cardsToJson)
  ObservableList<CardModel> cards;

  // CONVERTERS

  static ObservableList<CardModel> _cardsFromJson(List<dynamic> json) =>
      ObservableList.of(
        json.map((x) => CardModel.fromJson(x as Map<String, dynamic>)),
      );

  static List<Map<String, dynamic>> _cardsToJson(
    ObservableList<CardModel> cards,
  ) {
    return cards.map((x) => x.toJson()).toList();
  }
}
