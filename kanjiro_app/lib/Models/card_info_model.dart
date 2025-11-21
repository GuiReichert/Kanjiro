import 'package:kanjiro_app/Utils/Enums/jlpt_level.dart';

class CardInfoModel {
  CardInfoModel({
    required this.jlptLevel,
    required this.front,
    required this.back,
    required this.kanji,
    required this.readings,
    required this.exampleWords,
    required this.additionalInfo,
  });

  final JlptLevel jlptLevel;
  final String front;
  final String back;
  final String kanji;
  final List<String> readings;
  final List<String> exampleWords;
  final String additionalInfo;
}
