import 'package:kanjiro_app/Models/card_model.dart';

class DeckModel {
  DeckModel({required this.name, required this.cards});

  final String name;
  final List<CardModel> cards;
}
