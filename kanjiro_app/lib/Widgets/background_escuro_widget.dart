import 'package:flutter/material.dart';

class KanjiroBackgroundEscuro extends StatelessWidget {
  const KanjiroBackgroundEscuro({super.key, required this.widgetFilho});

  final Widget widgetFilho;

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: BoxDecoration(
        image: DecorationImage(
          image: AssetImage('assets/images/mainedited.png'),
          fit: BoxFit.cover,
          colorFilter: ColorFilter.mode(
            Colors.white.withValues(alpha: 0.3),
            BlendMode.modulate,
          ),
        ),
        gradient: LinearGradient(
          colors: [const Color.fromARGB(255, 58, 60, 183), Colors.blueGrey],
          begin: Alignment.topLeft,
          end: Alignment.bottomRight,
        ),
      ),
      child: widgetFilho,
    );
  }
}
