import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:kanjiro_app/Models/card_info_model.dart';
import 'package:kanjiro_app/ViewModels/kanji_info_viewmodel.dart';

class KanjiInfoCard extends StatelessWidget {
  const KanjiInfoCard({super.key, required this.cardInfo});
  final CardInfoModel cardInfo;

  @override
  Widget build(BuildContext context) {
    final viewmodel = KanjiInfoViewmodel(card: cardInfo);
    viewmodel.init();

    return Observer(builder: (_) => _conteudo(context, viewmodel));
  }

  Padding _conteudo(BuildContext context, KanjiInfoViewmodel viewmodel) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 30, vertical: 100),
      child: Card(
        child: Column(
          children: [
            SizedBox(height: 50),
            Text(cardInfo.front, style: TextStyle(fontSize: 30)),
            SizedBox(height: 30),
            Text(cardInfo.back, style: TextStyle(fontSize: 30)),
            SizedBox(height: 30),
            Text(
              'JLPT Level: ${cardInfo.jlptLevel}',
              style: TextStyle(fontSize: 30),
            ),
            SizedBox(height: 30),
            Text(
              'Additional Info: ${cardInfo.additionalInfo}',
              style: TextStyle(fontSize: 30),
            ),
            Spacer(),
            Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                IconButton(
                  onPressed:
                      viewmodel.addedToDeck
                          ? null
                          : () {
                            viewmodel.addKanjiToDeck();
                            ScaffoldMessenger.of(context).clearSnackBars();
                            ScaffoldMessenger.of(context).showSnackBar(
                              SnackBar(
                                content: Text(
                                  '${cardInfo.front} adicionado ao deck.',
                                ),
                              ),
                            );
                          },
                  icon: Icon(Icons.add),
                  iconSize: 50,
                  disabledColor: Colors.black.withValues(alpha: 0.1),
                  style: ButtonStyle(elevation: WidgetStatePropertyAll(1)),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
