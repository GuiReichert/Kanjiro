class KanjiroApiException implements Exception {
  KanjiroApiException({required this.message});

  final String message;

  @override
  String toString() {
    return 'Erro da API: $message';
  }
}
