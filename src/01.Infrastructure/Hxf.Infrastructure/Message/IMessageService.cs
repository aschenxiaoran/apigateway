namespace Hxf.Infrastructure.Message {

    /// <summary>
    /// 消息服务接口
    /// </summary>
    public interface IMessageService{

        void PublishMessage(string messageKey, MessageTopicType topicType,string messageBody);


    }

    public class MessageResult{
    }
}
