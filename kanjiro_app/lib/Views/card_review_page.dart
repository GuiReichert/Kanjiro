import 'package:flutter/material.dart';
import 'package:kanjiro_app/Models/card_model.dart';
import 'package:kanjiro_app/ViewModels/user_deck_viewmodel.dart';
import 'package:kanjiro_app/Widgets/background_claro_widget.dart';
import 'package:flutter_mobx/flutter_mobx.dart';

class CardReviewPage extends StatefulWidget {
  const CardReviewPage({super.key, required this.deckViewModel});

  final UserDeckViewmodel deckViewModel;

  @override
  State<CardReviewPage> createState() => _CardReviewPageState();
}

class _CardReviewPageState extends State<CardReviewPage> {
  bool mostrarResposta = false;
  late CardModel currentCard = widget.deckViewModel.nextCardToReview!;

  @override
  Widget build(BuildContext context) {
    return Observer(
      builder:
          (_) => Scaffold(
            body: KanjiroBackgroundClaro(
              widgetFilho: Center(
                child: Container(
                  decoration: BoxDecoration(
                    color: Colors.white.withValues(alpha: 0.75),
                  ),
                  child: Center(
                    child: Text(
                      mostrarResposta
                          ? currentCard.cardInfo.back
                          : currentCard.cardInfo.front,
                      style: TextStyle(
                        fontSize: 35,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                ),
              ),
            ),
            appBar: barraSuperiorCardReview(),
            bottomNavigationBar: BottomAppBar(
              color: const Color.fromARGB(255, 42, 75, 105),
              child:
                  mostrarResposta
                      ? botoesDificuldade()
                      : botaoMostrarResposta(),
            ),
          ),
    );
  }

  Center botaoMostrarResposta() {
    return Center(
      child: ElevatedButton(
        onPressed: () {
          setState(() {
            mostrarResposta = true;
          });
        },
        child: Text('Mostrar Resposta'),
      ),
    );
  }

  Row botoesDificuldade() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
      children: [
        ElevatedButton(
          onPressed: () {
            responderCarta(1.5);
          },
          child: Text('Easy'),
        ),
        ElevatedButton(
          onPressed: () {
            responderCarta(1.3);
          },
          child: Text('Normal'),
        ),
        ElevatedButton(
          onPressed: () {
            responderCarta(1.2);
          },
          child: Text('Hard'),
        ),
      ],
    );
  }

  AppBar barraSuperiorCardReview() {
    return AppBar(
      backgroundColor: const Color.fromARGB(255, 42, 75, 105),
      elevation: 1,
    );
  }

  void responderCarta(double multiplier) {
    widget.deckViewModel.updateCardReviewDate(currentCard, multiplier);
    var nextCard = widget.deckViewModel.nextCardToReview;

    if (nextCard == null) {
      showDialog(
        context: context,
        builder:
            (_) => AlertDialog(
              title: Text('Atenção'),
              content: Text(
                'Você terminou de responder todas as cartas de hoje!',
              ),
              actions: [
                TextButton(
                  onPressed: () {
                    Navigator.pop(context);
                    Navigator.pop(context);
                  },
                  child: Text('Ok'),
                ),
              ],
            ),
      );
      return;
    } else {
      currentCard = nextCard;
    }

    setState(() {
      mostrarResposta = false;
    });
  }
}
