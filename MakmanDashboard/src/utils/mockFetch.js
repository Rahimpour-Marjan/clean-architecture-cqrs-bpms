export const mockFetch = data => {
  return new Promise((resolve, _) => {
    setTimeout(() => {
      resolve(data);
    }, 1000);
  });
};
