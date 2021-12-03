

const host = `http://localhost:3030`;

async function request(url, options) {

    const res = await fetch(host + url, options);

    try {

        if (!res.ok) {
            const err = res.json();
            throw new Error(err.message);
        }

        try {

            return await res.json();

        } catch (error) {

            return res;
        }

    } catch (error) {
        alert(error.message);
        throw error;
    }
}

function createOptions(method = `get`, data) {

    const options = {

        method,
        headers: {}
    }

    if (data != undefined) {

        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const token = sessionStorage.getItem('token');

    if (token) {

        options.headers['X-Authorization'] = token;
    }

    return options;
}

export async function get(url) {

    return await request(url, createOptions());
}

export async function post(url, data) {

    return await request(url, createOptions('post', data));
}

export async function put(url, data) {

    return await request(url, createOptions('put', data));
}

export async function del(url) {

    return await request(url, createOptions('delete'));
}

export async function login(username, password) {

    const user = await post('/users/login', { username, password });

    sessionStorage.setItem('username', user.username);
    sessionStorage.setItem('userId', user._id);
    sessionStorage.setItem('token', user.accessToken);

    return user;
}

export async function register(username, password) {

    const user = await post('/users/register', { username, password });

    sessionStorage.setItem('username', user.username);
    sessionStorage.setItem('userId', user._id);
    sessionStorage.setItem('token', user.accessToken);

    return user;
}

export async function logout() {

    await get('/users/logout');

    sessionStorage.removeItem('username');
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('token');
}