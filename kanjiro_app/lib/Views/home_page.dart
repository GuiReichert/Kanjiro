import 'package:flutter/material.dart';

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        decoration: BoxDecoration(
          gradient: LinearGradient(
            colors: [
              const Color.fromARGB(131, 58, 60, 183),
              const Color.fromARGB(117, 96, 125, 139),
            ],
            begin: Alignment.topCenter,
            end: Alignment.bottomCenter,
          ),
          image: DecorationImage(
            image: AssetImage('assets/images/mainedited.png'),
            colorFilter: ColorFilter.mode(
              Colors.white.withOpacity(0.3),
              BlendMode.modulate,
            ),
            fit: BoxFit.contain,
          ),
        ),
        child: Center(
          child: Container(
            height: 750,
            width: 375,
            decoration: BoxDecoration(
              color: Colors.white.withOpacity(0.7),
              borderRadius: BorderRadius.circular(8),
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
        ),
      ),
      bottomNavigationBar: BottomAppBar(
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
      ),
    );
  }
}
