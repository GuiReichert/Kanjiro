import 'package:flutter/material.dart';

class KanjiroBackgroundClaro extends StatelessWidget {
  const KanjiroBackgroundClaro({super.key, required this.widgetFilho});

  final Widget widgetFilho;

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        gradient: LinearGradient(
          colors: [const Color.fromARGB(255, 55, 78, 206), Colors.blueGrey],
          begin: Alignment.topLeft,
          end: Alignment.bottomRight,
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
      child: widgetFilho,
    );
  }
}
