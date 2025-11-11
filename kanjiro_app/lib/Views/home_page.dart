import 'package:flutter/material.dart';
import 'package:kanjiro_app/Widgets/background_claro_widget.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: KanjiroBackgroundClaro(widgetFilho: conteudo()),
      bottomNavigationBar: barraInferior(),
    );
  }

  Center conteudo() {
    return Center(
      child: Container(
        height: 750,
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
              'Bom dia, vamos estudar seu deck hoje?',
              style: TextStyle(
                fontWeight: FontWeight.bold,
                fontSize: 30,
                color: Colors.black,
              ),
              textAlign: TextAlign.center,
            ),
            SizedBox(height: 30),
            ElevatedButton(onPressed: () {}, child: Text('Revisar')),
          ],
        ),
      ),
    );
  }

  BottomAppBar barraInferior() {
    return BottomAppBar(
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          Column(
            children: [
              Container(color: Colors.black12, height: 35, width: 35),
              Text('Revisões'),
            ],
          ),
          Column(
            children: [
              Container(color: Colors.black12, height: 35, width: 35),
              Text('Pesquisa'),
            ],
          ),
          Column(
            children: [
              Container(color: Colors.black12, height: 35, width: 35),
              Text('Configurações'),
            ],
          ),
        ],
      ),
    );
  }
}
