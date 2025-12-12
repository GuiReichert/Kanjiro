import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:injector/injector.dart';
import 'package:kanjiro_app/ViewModels/kanji_search_viewmodel.dart';

class KanjiSearchPage extends StatefulWidget {
  const KanjiSearchPage({super.key});

  @override
  State<KanjiSearchPage> createState() => _KanjiSearchPageState();
}

class _KanjiSearchPageState extends State<KanjiSearchPage> {
  var viewmodel = Injector.appInstance.get<KanjiSearchViewmodel>();

  var searchTxtController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        actions: [
          IconButton(onPressed: _searchClick, icon: Icon(Icons.search)),
        ],
        title: TextField(
          controller: searchTxtController,
          decoration: InputDecoration(
            hint: Text(
              'Pesquisar',
              style: TextStyle(color: Colors.black.withValues(alpha: 0.4)),
            ),
          ),
        ),
      ),
      body: Observer(
        builder: (_) {
          if (viewmodel.searchResults.isEmpty) {
            return Center(
              child: Text('Nenhum resultado encontrado'),
            );
          }
          return _conteudo();
        },
      ),
    );
  }

  ListView _conteudo() {
    return ListView(
      children: [
        for (var result in viewmodel.searchResults)
          Card(
            color: Colors.grey,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                Text(result.front),
                Text(result.back),
                IconButton(
                  onPressed: () {},
                  icon: Icon(Icons.arrow_forward_ios),
                ),
              ],
            ),
          ),
      ],
    );
  }

  Future<void> _searchClick() async {
    await viewmodel.searchKanjiByText(searchTxtController.text);
  }
}
