const axios = require('axios');

function renderTemplate(repository, actor, eventName, 
  commitMessage, commitHash, feStatus, beStatus, time) {

  const template = `📢 **GitHub Notification**
  📚 **Repository:** [${repository}](https://github.com/${repository})
  👀 **Author:** ${actor}
  👉 **Event:** ${eventName}
  ⏰ **Time:** ${time}
  
  ----
  🔨 **Build Front-end:** ${feStatus}
  🔧 **Build Back-end:** ${beStatus}

  ----
  📌 **Commit Message:** ${commitMessage}
  🔗 **Commit Details:** [View Commit](https://github.com/${repository}/commit/${commitHash})
  
  ----
  🌟❤️ Keep up the great work! 🚀❤️ `;
  
  return template;
}

async function sendTelegramMessage(repository, actor, eventName, commitMessage, commitHash, feStatus, beStatus) {
  const now = new Date();
  const options = { timeZone: 'Asia/Ho_Chi_Minh' };
  const formattedTime = now.toLocaleString('en-US', options);
  const message = renderTemplate(repository, actor, eventName, 
    commitMessage, commitHash, feStatus, beStatus, formattedTime);

  const requestBody = {
    chat_id: process.env.TELEGRAM_TO,
    text: message,
    parse_mode: 'Markdown',
  };

  const url = `https://api.telegram.org/bot${process.env.TELEGRAM_TOKEN}/sendMessage`;

  try {
    await axios.post(url, requestBody);
    console.log('Telegram message sent successfully!');
  } catch (error) {
    console.error('Failed to send Telegram message:', error);
  }
}

sendTelegramMessage(process.argv[2], process.argv[3], process.argv[4],
  process.argv[5], process.argv[6], process.argv[7], process.argv[8]);
