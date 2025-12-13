import 'package:flutter/material.dart';
import 'package:kanjiro_app/ViewModels/user_viewmodel.dart';
import 'package:kanjiro_app/Views/card_review_page.dart';
import 'package:kanjiro_app/Widgets/background_claro_widget.dart';
import 'package:kanjiro_app/Widgets/main_page_drawer.dart';
import 'package:flutter_mobx/flutter_mobx.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key, required this.userViewModel});

  final UserViewmodel userViewModel;

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  @override
  Widget build(context) {
    return Scaffold(
      drawer: MainPageDrawer(),
      appBar: AppBar(
        title: Center(child: Text('Kanjiro')),
        backgroundColor: const Color.fromARGB(255, 127, 155, 182),
        actions: [
          IconButton(
            onPressed: () async {
              var mensagem = 'Sincronização concluída com sucesso.';

              try {
                await widget.userViewModel.synchronizeChanges();
              } catch (e) {
                mensagem = e.toString();
              }

              if (!context.mounted) return;

              ScaffoldMessenger.of(context).clearSnackBars();
              ScaffoldMessenger.of(
                context,
              ).showSnackBar(SnackBar(content: Text(mensagem)));
            },
            icon: Icon(Icons.sync),
          ),
          SizedBox(
            width: 15,
          ),
        ],
      ),
      body: KanjiroBackgroundClaro(
        widgetFilho: Observer(builder: (_) => conteudo()),
      ),
      bottomNavigationBar: barraInferior(),
    );
  }

  conteudo() {
    return Center(
      child: Padding(
        padding: const EdgeInsets.only(top: 20, bottom: 30),
        child: Container(
          height: 700,
          width: 375,
          decoration: BoxDecoration(
            color: const Color.fromARGB(
              255,
              224,
              220,
              233,
            ).withValues(alpha: 0.7),
            borderRadius: BorderRadius.circular(8),
            boxShadow: [
              BoxShadow(
                color: Colors.black26,
                blurRadius: 8,
                offset: Offset(0, 4),
              ),
            ],
          ),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                'Bom dia, vamos estudar seu deck hoje? \n Cartas a revisar: ${widget.userViewModel.deckViewmodel.cardsToReview.length}',
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: 30,
                  color: Colors.black,
                ),
                textAlign: TextAlign.center,
              ),
              SizedBox(height: 30),
              ElevatedButton(
                onPressed: () {
                  _revisarDeck(context);
                },
                child: Text('Revisar'),
              ),
            ],
          ),
        ),
      ),
    );
  }

  BottomAppBar barraInferior() {
    return BottomAppBar(
      color: const Color.fromARGB(255, 127, 155, 182),
      elevation: 1,
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          InkWell(
            onTap: () {},
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Icon(Icons.tab),
                SizedBox(height: 5),
                Text('Aba 1'),
              ],
            ),
          ),
          InkWell(
            onTap: () {},
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Icon(Icons.tab),
                SizedBox(height: 5),
                Text('Aba 2'),
              ],
            ),
          ),
          InkWell(
            onTap: () {},
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Icon(Icons.tab),
                SizedBox(height: 5),
                Text('Aba 3'),
              ],
            ),
          ),
        ],
      ),
    );
  }

  void _revisarDeck(ctx) {
    if (widget.userViewModel.deckViewmodel.cardsToReview.isEmpty) {
      showDialog(
        context: ctx,
        builder:
            (_) => AlertDialog(
              title: Text('Atenção'),
              content: Text('Nenhuma carta para revisar'),
              actions: [
                TextButton(
                  onPressed: () => Navigator.pop(ctx),
                  child: Text('Ok'),
                ),
              ],
            ),
      );
      return;
    }

    Navigator.push(
      ctx,
      MaterialPageRoute(
        builder:
            (ctx) => CardReviewPage(
              deckViewModel: widget.userViewModel.deckViewmodel,
            ),
      ),
    );
  }
}
