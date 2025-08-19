import 'package:flutter/material.dart';
import 'package:kanjiro_app/Widgets/background_claro_widget.dart';

class CardReviewPage extends StatelessWidget {
  const CardReviewPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: KanjiroBackgroundClaro(widgetFilho: Container()),
      bottomNavigationBar: BottomAppBar(),
    );
  }
}
