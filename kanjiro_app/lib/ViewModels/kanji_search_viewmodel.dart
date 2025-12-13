import 'package:kanjiro_app/Models/card_info_model.dart';
import 'package:kanjiro_app/Services/api_service.dart';
import 'package:mobx/mobx.dart';

part 'kanji_search_viewmodel.g.dart';

class KanjiSearchViewmodel = KanjiSearchViewmodelBase
    with _$KanjiSearchViewmodel;

abstract class KanjiSearchViewmodelBase with Store {
  @observable
  List<CardInfoModel> searchResults = [];

  @action
  Future<void> searchKanjiByText(String text) async {
    var teste = await ApiService.searchKanjiByText(text);
    searchResults = teste;
  }

  @action
  Future<void> addKanjiToDeck(CardInfoModel card, int deckId) async {
    await ApiService.addKanjiToDeck(card.id, deckId);
  }
}
