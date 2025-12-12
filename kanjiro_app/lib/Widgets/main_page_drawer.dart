import 'package:flutter/material.dart';
import 'package:kanjiro_app/Views/kanji_search_page.dart';
import 'package:kanjiro_app/Views/login_page.dart';

class MainPageDrawer extends StatefulWidget {
  const MainPageDrawer({super.key});

  @override
  State<MainPageDrawer> createState() => _MainPageDrawerState();
}

class _MainPageDrawerState extends State<MainPageDrawer> {
  @override
  Widget build(BuildContext context) {
    return Drawer(
      backgroundColor: const Color.fromARGB(255, 42, 75, 105),
      elevation: 1,
      child: Column(
        children: [
          SizedBox(height: 50),
          _categoriaDrawer('Categoria 1', Icons.school),
          _botaoDrawer(
            'Pesquisa',
            Icons.search,
            onButtonTap:
                () => Navigator.push(
                  context,
                  MaterialPageRoute(builder: (_) => KanjiSearchPage()),
                ),
          ),
          _botaoDrawer('Progresso', Icons.stacked_line_chart_rounded),

          _categoriaDrawer('Categoria 2', Icons.texture_sharp),
          _botaoDrawer('Meu Deck', Icons.my_library_books),
          _botaoDrawer('Nivelamento', Icons.account_tree_outlined),

          Spacer(),
          _categoriaDrawer('Categoria 2', Icons.person),
          _botaoDrawer('Versão Pro', Icons.shopping_cart),
          _botaoDrawer('Configurações', Icons.settings),
          _botaoDrawer('Sair', Icons.logout, onButtonTap: _botaoSairPressed),
          SizedBox(height: 30),
        ],
      ),
    );
  }

  Container _categoriaDrawer(String texto, IconData icone) {
    return Container(
      width: double.infinity,
      height: 40,
      decoration: BoxDecoration(
        color: const Color.fromARGB(255, 127, 155, 182),
      ),
      child: Row(
        children: [
          SizedBox(width: 10),
          Icon(icone),
          SizedBox(width: 10),
          Text(
            texto,
            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
          ),
        ],
      ),
    );
  }

  ListTile _botaoDrawer(
    String texto,
    IconData icone, {
    void Function()? onButtonTap,
  }) {
    return ListTile(
      leading: Icon(icone, color: Colors.white),
      title: Text(
        texto,
        style: TextStyle(
          color: Colors.white,
          fontWeight: FontWeight.bold,
        ),
      ),
      onTap: () {
        if (onButtonTap != null) {
          onButtonTap();
        }
      },
    );
  }

  void _botaoSairPressed() {
    Navigator.pushReplacement(
      context,
      MaterialPageRoute(builder: (context) => LoginPage()),
    );
  }
}
