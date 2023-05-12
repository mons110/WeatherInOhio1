using Domain.Models;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using static System.Net.Mime.MediaTypeNames;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var botClent = new TelegramBotClient("5900457343:AAE5kIlR0zR3mJ6U_fyh6JGtGuUudwNPm_8");
            HttpClient client = new HttpClient();
            var res = await client.GetAsync("https://localhost:7171/api/BD");
            using CancellationTokenSource cts = new();
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClent.StartReceiving(
                updateHandler: HandleBlaBla,
                pollingErrorHandler: HandleErrorsAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token);
            var me = await botClent.GetMeAsync();
            Console.WriteLine($"Слушаю @{me.Username}");
            Console.WriteLine(res.ToString());
            var test = await res.Content.ReadAsStringAsync();
            Console.WriteLine(test);

            Tovari[] good = JsonConvert.DeserializeObject<Tovari[]>(test);
            foreach (Tovari tovari in good)
            {
                Console.WriteLine(tovari.Id + " " + tovari.Title + " " + tovari.Price);
            }
            Console.ReadLine();

            cts.Cancel();
        }

        static async Task HandleBlaBla(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            if (update.Message is not { } message)
                return;
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;
            Console.WriteLine($"Received a '{messageText}' message in chat '{chatId}'");
            if (message.Text == "Проверка")
            {
                await botClient.SendTextMessageAsync(chatId: chatId,
                text: "Круто",
                cancellationToken: cancellationToken);
            }
            if (message.Text == "Товары")
            {
                HttpClient client = new HttpClient();
                var res = await client.GetAsync("https://localhost:7171/api/BD");
                var test = await res.Content.ReadAsStringAsync();
                Tovari[] good = JsonConvert.DeserializeObject<Tovari[]>(test);
                foreach (Tovari tovari in good)
                {
                    await botClient.SendTextMessageAsync(chatId: chatId,
                text: tovari.Id + " " + tovari.Title + " " + tovari.Price + " ",
                cancellationToken: cancellationToken);
                }
            }
            if (message.Text == "Дай фото Рамзеса")
            {
                await botClient.SendPhotoAsync(chatId: chatId,
                photo: "https://i.redd.it/9es4n8q8hkua1.jpg",
                caption: "hehe",
                cancellationToken: cancellationToken);
            }
            if (message.Text == "Турнир дота 2")
            {
                await botClient.SendVideoAsync(chatId: chatId,
                video: "https://cdn.discordapp.com/attachments/830763703216635909/1103952059042119720/Bounty_hunter_.mp4",
                thumb: "https://sun3-18.userapi.com/impg/Z4HapWDqLUKChTjGccnrqXIvRXUA-zUCLOtqTw/xIsrmjGzcAc.jpg?size=744x683&quality=96&sign=99ee26646714d4b315f17a5614dcfef0&type=album",
                supportsStreaming: true,
                cancellationToken: cancellationToken);
            }
            if (message.Text == "Бот стикер")
            {
                await botClient.SendStickerAsync(chatId: chatId,
                sticker: "CAACAgIAAxkBAAEgq9FkVLblhjtBstNMQ304mAUYFUwAATUAAi0aAAJiiHhIRUmH6w9CxmovBA",
                cancellationToken: cancellationToken);
            }
            if (message.Text == "Кнопки в студию")
            {
                var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(new[]
 {
    new [] // first row
    {
        InlineKeyboardButton.WithUrl("1.1","www.google.com"),
        InlineKeyboardButton.WithCallbackData("1.2"),
    },
    new [] // second row
    {
        InlineKeyboardButton.WithUrl("2.1","github.com"),
        InlineKeyboardButton.WithCallbackData("2.2"),
    }
});
                await botClient.SendTextMessageAsync(chatId, "Жамкни!", replyMarkup: keyboard);
            }

        }
        static Task HandleErrorsAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorM = exception switch
            {
                ApiRequestException apiRequestException =>
                $"Telegram Bot Error:\n [{apiRequestException.ErrorCode}]\n {apiRequestException.Message}",
                _ => exception.ToString()
            };
            Console.WriteLine(ErrorM);
            return Task.CompletedTask;
        }
    }
}