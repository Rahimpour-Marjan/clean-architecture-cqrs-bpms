import styled from 'styled-components';
import { Loader } from '../../components';
import { usePosts } from '../../hooks/usePosts';
import { Pagination } from '../pagination';
import { AddPost } from './AddPost';
import { PostOverview } from './PostOverview';

const Container = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-around;
`;

const PostsContainer = styled.div`
  display: grid;
  flex-direction: column;
  grid-template-columns: repeat(2, 1fr);
  grid-template-rows: repeat(2, 1fr);
  column-gap: 2rem;
  row-gap: 1rem;
  height: 70dvh;
  overflow: auto;

  @media (max-width: 800px) {
    grid-template-columns: 1fr;
    grid-template-rows: 1fr;
  }
`;

export const Posts = () => {
  const { error, isLoading, posts } = usePosts();

  return (
    <Container>
      <AddPost />
      {isLoading && !error && <Loader />}
      {!isLoading && error ? (
        <p>Something went wrong, please try again!</p>
      ) : (
        <PostsContainer>
          {posts?.map(p => (
            <PostOverview post={p} key={p.id} />
          ))}
        </PostsContainer>
      )}

      <Pagination />
    </Container>
  );
};
