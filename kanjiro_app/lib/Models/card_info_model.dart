import 'package:json_annotation/json_annotation.dart';
import 'package:kanjiro_app/Utils/Enums/jlpt_level.dart';

part 'card_info_model.g.dart';

@JsonSerializable(explicitToJson: true)
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

  factory CardInfoModel.fromJson(Map<String, dynamic> json) =>
      _$CardInfoModelFromJson(json);

  Map<String, dynamic> toJson() => _$CardInfoModelToJson(this);
}
