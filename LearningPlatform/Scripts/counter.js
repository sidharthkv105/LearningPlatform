function updateCountdown() {
    const now = new Date();
    let nextRewardTime = new Date();

    nextRewardTime.setHours(13, 0, 0, 0); // 1 PM today

    if (now.getHours() >= 13) {
        nextRewardTime.setDate(nextRewardTime.getDate() + 1);
    }

    const timeDifference = nextRewardTime - now;

    if (timeDifference <= 0) {
        document.getElementById('countdown').textContent = "Reward is now available!";
    } else {
        const hours = Math.floor(timeDifference / (1000 * 60 * 60));
        const minutes = Math.floor((timeDifference % (1000 * 60 * 60)) / (1000 * 60));
        const seconds = Math.floor((timeDifference % (1000 * 60)) / 1000);

        document.getElementById('countdown').textContent = `${hours}h ${minutes}m ${seconds}s`;
    }

    setTimeout(updateCountdown, 1000);
}

window.onload = function () {
    updateCountdown();
};
