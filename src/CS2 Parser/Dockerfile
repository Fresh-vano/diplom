# Используем официальный образ Go
FROM golang:1.18 as builder

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем go.mod и go.sum
COPY go.mod ./
COPY go.sum ./

# Загружаем зависимости
RUN go mod download

# Копируем исходный код проекта
COPY *.go ./

# Собираем бинарный файл
RUN CGO_ENABLED=0 GOOS=linux go build -o main .

# Используем официальный образ scratch для минимального размера
FROM scratch

WORKDIR /

# Копируем бинарный файл из первого этапа
COPY --from=builder /app/main .

# Определяем порт, который будет прослушивать приложение
EXPOSE 8080

# Команда для запуска
CMD ["/main"]
