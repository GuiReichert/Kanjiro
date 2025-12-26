import 'package:flutter/material.dart';
import 'package:kanjiro_app/Models/placement_test_card_model.dart';
import 'package:kanjiro_app/ViewModels/placement_test_viewmodel.dart';
import 'package:flutter_mobx/flutter_mobx.dart';

class PlacementTestPage extends StatefulWidget {
  PlacementTestPage({super.key});

  @override
  State<PlacementTestPage> createState() => _PlacementTestPageState();

  final viewmodel = PlacementTestViewmodel();
}

class _PlacementTestPageState extends State<PlacementTestPage> {
  @override
  void initState() {
    super.initState();
    widget.viewmodel.init();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Prova de Nivelamento'),
      ),
      body: Observer(
        builder: (_) {
          return widget.viewmodel.isLoading
              ? Center(child: Text('Carregando'))
              : Column(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Expanded(
                    child: GridView(
                      padding: EdgeInsets.all(24),
                      gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 3,
                      ),
                      children: [
                        for (var kanji
                            in widget.viewmodel.currentLevelPlacementCards)
                          _selectableCard(kanji),
                      ],
                    ),
                  ),
                  widget.viewmodel.isSecondPhase
                      ? ElevatedButton(
                        onPressed: () {},
                        child: Text('Finalizar'),
                      )
                      : ElevatedButton(
                        onPressed: widget.viewmodel.nextPage,
                        child: Text('Avançar'),
                      ),
                  SizedBox(height: 40),
                ],
              );
        },
      ),
    );
  }

  _selectableCard(PlacementTestCardModel card) {
    return Card(
      elevation: card.isSelected ? 2 : 8,
      color: Colors.white,
      shape: RoundedRectangleBorder(
        side: BorderSide(
          color: card.isSelected ? Colors.black : Colors.grey.shade200,
        ), // or
        borderRadius: BorderRadiusGeometry.circular(12),
      ),
      child: InkWell(
        onTap: () => {widget.viewmodel.selectCard(card)},
        borderRadius: BorderRadius.circular(12),
        child: Padding(
          padding: EdgeInsets.all(16),
          child: Center(
            child: Text(card.cardInfo.front, style: TextStyle(fontSize: 30)),
          ),
        ),
      ),
    );
  }
}
