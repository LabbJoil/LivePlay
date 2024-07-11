
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Core.CustomExceptions;
using LivePlay.Server.Core.Enums;
using LivePlay.Server.Persistence;
using LivePlay.Server.Persistence.EntityModels.Base;

namespace LivePlay.Server.WebApi.ProgramExtentions;

public static class ServiceLifetime
{
    public static void ControlAppLifetime(this WebApplication app)
    {
        app.Lifetime.ApplicationStopping.Register(app.OnApplicationStopping);
        app.Lifetime.ApplicationStarted.Register(app.OnApplicationStarted);
    }

    public static void OnApplicationStopping(this WebApplication app)
    {
        var emailProvider = app.Services.GetService<IEmailProvider>()
            ?? throw new ServerException(ErrorCode.ServerError, $"Service {nameof(IEmailProvider)} not found");
        emailProvider.Disconect();
        app.Logger.LogInformation("All services stoped");
    }

    // INFO: Time
    public static void OnApplicationStarted(this WebApplication app)
    {
        return;
        using var scope = app.Services.CreateScope();
        var livePlayDbContext = scope.ServiceProvider.GetService<LivePlayDbContext>()
            ?? throw new ServerException(ErrorCode.ServerError, $"Service {nameof(LivePlayDbContext)} not found");

        if (livePlayDbContext.News.Count() > 1)
            return;

        var path = @"C:\Users\levt1\Desktop\";
        var newNews1 = new NewsEntityModel
        {
            Name = "Новый отель открывается в живописном горном регионе",
            Description = "С гордостью объявляем об открытии нового отеля",
            Text = "Сеть отелей рада сообщить об открытии своего нового флагманского курорта в живописном горном регионе. Расположенный в окружении величественных горных вершин и нетронутой природы, этот курорт предлагает гостям уникальную возможность насладиться роскошным отдыхом в гармонии с окружающей средой.\r\nКурорт располагает просторными номерами с панорамными видами, изысканными ресторанами с блюдами местной кухни, спа-центром с широким выбором оздоровительных процедур, а также разнообразными возможностями для активного отдыха, включая пешие прогулки, альпинизм и катание на лыжах. Команда высококвалифицированных специалистов обеспечит гостям незабываемый и комфортный отдых.\r\nОткрытие нового курорта является важным этапом в развитии сети отелей и демонстрирует ее приверженность предоставлению исключительного гостиничного опыта в уникальных природных локациях. Приглашаем всех ценителей роскошного отдыха и живописных пейзажей посетить наш новый курорт и насладиться незабываемым отпуском.",
            Image = File.ReadAllBytes(path + "Picture1.png")
        };
        var newNews2 = new NewsEntityModel
        {
            Name = "Запуск новой программы лояльности для постоянных клиентов",
            Description = "Представляем новую программу лояльности",
            Text = "Сеть отелей с радостью объявляет о запуске своей новой программы лояльности, которая призвана предложить постоянным клиентам еще больше преимуществ и привилегий. Эта всеобъемлющая программа разработана с учетом пожеланий и предпочтений наших самых ценных гостей, чтобы сделать их пребывание в наших отелях еще более комфортным и незабываемым.\r\nКлючевые особенности новой программы лояльности включают:\r\nРасширенные привилегии при бронировании, такие как гарантированное наличие номеров, ранний заезд и поздний выезд, а также возможность бесплатного повышения категории номера.\r\nЭксклюзивные предложения и специальные тарифы, доступные только для участников программы.\r\nНакопление и использование бонусных баллов для оплаты проживания, питания, спа-процедур и других услуг.\r\nПерсональный менеджер, который будет сопровождать участников программы и помогать в организации их поездок.\r\nПриглашения на закрытые мероприятия и эксклюзивные мероприятия для постоянных клиентов.\r\n\"Мы высоко ценим лояльность наших постоянных гостей и стремимся предложить им еще больше преимуществ и привилегий, - говорит директор по маркетингу сети отелей. - Наша новая программа лояльности станет воплощением нашей благодарности и стремления сделать их пребывание в наших отелях по-настоящему незабываемым.\"\r\nПрисоединиться к программе лояльности можно уже сегодня на нашем сайте или в любом из наших отелей. Мы с нетерпением ждем возможности предложить нашим постоянным клиентам еще больше эксклюзивных преимуществ и персонализированного сервиса.",
            Image = File.ReadAllBytes(path + "Picture2.png")
        };

        livePlayDbContext.Add(newNews1);
        livePlayDbContext.Add(newNews2);
        livePlayDbContext.SaveChanges();
    }
}
